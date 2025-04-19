from dataclasses import dataclass
from uuid import UUID
import uuid

@dataclass
class FlashcardTemplate:
    name: str
    id: UUID = uuid.uuid4()