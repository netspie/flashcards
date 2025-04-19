from dataclasses import dataclass, field
from typing import Optional
from uuid import UUID

from basic.app.repository import Repository
from .concept_template import ConceptTemplate

@dataclass
class ConceptTemplateRepository(Repository[ConceptTemplate, UUID]):
    _data: dict[UUID, ConceptTemplate] = field(default_factory=dict)

    async def get_all(self) -> Optional[list[ConceptTemplate]]:
        return list(self._data.values()) if self._data else None

    async def get_by_id(self, id: UUID) -> Optional[ConceptTemplate]:
        return self._data.get(id, None)

    async def add(self, item: ConceptTemplate) -> None:
        self._data[item.id] = item

    async def update(self, item: ConceptTemplate) -> None:
        self._data[item.id] = item

    async def delete(self, id: UUID) -> bool:
        return self._data.pop(id, None) is not None