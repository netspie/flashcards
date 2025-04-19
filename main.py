
from fastapi import FastAPI

from features.concepts_templates.entity.concept_template_repository import ConceptTemplateRepository
from features.deps import get_concept_template_repository

from features.concepts_templates.get_concept_template import router as router_get_concept_template
from features.concepts_templates.add_concept_template import router as router_add_concept_template

app = FastAPI()
app.dependency_overrides[get_concept_template_repository] = lambda: ConceptTemplateRepository()
app.include_router(router_get_concept_template, prefix="/api")
app.include_router(router_add_concept_template, prefix="/api")