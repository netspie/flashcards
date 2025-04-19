from dataclasses import dataclass
from uuid import UUID
import uuid

from basic.app.repository import Repository
from features.flashcard_templates.flashcard_template import FlashcardTemplate

@dataclass(frozen=True)
class AddFlashcardTemplateCommand:
    name: str

@dataclass(frozen=True)
class AddFlashcardTemplateCommandHandler:
    repository: Repository[FlashcardTemplate, UUID]

    async def handle(self, cmd: AddFlashcardTemplateCommand):
        x = FlashcardTemplate(id=uuid.uuid4(), name=cmd.name)
        await self.repository.add(x)

@dataclass(frozen=True)
class AddFlashcardTemplateCommandValidator:
    repository: Repository[FlashcardTemplate, UUID]

    def validate(self, cmd: AddFlashcardTemplateCommand) -> bool:
        if len(cmd.name) == 0: 
            return False
        
        return True
