from __future__ import annotations

from dataclasses import dataclass
from typing import Optional
from uuid import UUID

@dataclass(frozen=True)
class FlashcardTemplateDTO:
    name: str
    concept_template_id: Optional[UUID]
    sides: list[Side]

    @dataclass(frozen=True)
    class Side:
        name: Optional[str]
        fields: list[Field]

        @dataclass(frozen=True)
        class Field:
            id: UUID
            name: Optional[str]