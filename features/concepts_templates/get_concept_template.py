from __future__ import annotations

from dataclasses import dataclass
from uuid import UUID
import uuid

from basic.app.repository import Repository

from fastapi import APIRouter, Depends, HTTPException

from .dtos.concept_template_dto import ConceptTemplateDTO
from .entity.concept_template import ConceptTemplate
from features.deps import get_concept_template_repository

router = APIRouter()

@router.get("/concept-templates")
async def route_add_concept_template(
    repository: Repository[ConceptTemplate, UUID] = Depends(get_concept_template_repository)):
    
    handler = GetConceptTemplatesCommandHandler(repository)
    result = await handler.handle(GetConceptTemplatesCommand())

    if not result:
        raise HTTPException(status_code=400, detail="Invalid command")

    return result

@dataclass(frozen=True)
class GetConceptTemplatesCommand: pass

@dataclass(frozen=True)
class GetConceptTemplatesCommandHandler:
    repository: Repository[ConceptTemplate, UUID]

    async def handle(self, cmd: GetConceptTemplatesCommand) -> list[ConceptTemplateDTO]:

        return [
            ConceptTemplateDTO(id=uuid.uuid4(), name="Word", properties=[
                "Native",
                "Furigana",
                "Translation",
                "Furigana",
                "Pitch Accent",
            ]),
            ConceptTemplateDTO(id=uuid.uuid4(), name="Phrase", properties=[
                "Native",
                "Furigana",
                "Translation"
            ])
        ]

        #return await self.repository.get_all()