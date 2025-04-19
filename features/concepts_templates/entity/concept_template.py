from __future__ import annotations
from dataclasses import dataclass
from uuid import UUID

@dataclass
class ConceptTemplate:
    id: UUID
    name: str
    properties: list[str]

# @dataclass(frozen=True)
# class ConceptTemplateProperty:
#     name: str
#     value: str
#     order: int