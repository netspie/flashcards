from dataclasses import dataclass
from uuid import UUID

@dataclass(frozen=True)
class ConceptTemplateDTO:
    id: UUID
    name: str
    properties: list[str]

    @dataclass(frozen=True)
    class Property:
        name: str
        value: str