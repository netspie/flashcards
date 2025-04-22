from uuid import UUID

from core.repository import Repository
from features.concepts_templates.entity.concept_template import ConceptTemplate

def get_concept_template_repository() -> Repository[ConceptTemplate, UUID]: ...