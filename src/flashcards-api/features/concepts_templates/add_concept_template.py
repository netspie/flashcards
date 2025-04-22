from __future__ import annotations

from dataclasses import dataclass
from uuid import UUID
import uuid

from core.repository import Repository

from fastapi import APIRouter, Depends, HTTPException

from .entity.concept_template import ConceptTemplate
from features.deps import get_concept_template_repository

router = APIRouter()

@router.post("/concept-templates")
async def add_concept_template(
    request: AddConceptTemplateCommand, 
    repository: Repository[ConceptTemplate, UUID] = Depends(get_concept_template_repository)):
    
    handler = AddConceptTemplateCommandHandler(repository)
    result = await handler.handle(request)

    if not result:
        raise HTTPException(status_code=400, detail="Invalid command")

    return {"status": "success"}

@dataclass(frozen=True)
class AddConceptTemplateCommand:
    name: str
    properties: list[str]

@dataclass(frozen=True)
class AddConceptTemplateCommandHandler:
    repository: Repository[ConceptTemplate, UUID]

    async def handle(self, cmd: AddConceptTemplateCommand):
        if not validate(cmd):
            return False

        concept_template = ConceptTemplate(uuid.uuid4(), cmd.name, cmd.properties)
        
        await self.repository.add(concept_template)

def validate(cmd: AddConceptTemplateCommand) -> bool:
    match cmd:
        case _ if len(cmd.properties) == 0: 
            return False
        
        case _ if any(not x for x in cmd.properties) == 0: 
            return False

        case _:
            return True