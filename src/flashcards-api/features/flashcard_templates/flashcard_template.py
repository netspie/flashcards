from __future__ import annotations

from dataclasses import dataclass
from datetime import datetime, timezone
from typing import Optional
from uuid import UUID
import uuid

from core.result_t import ResultT

MAX_SIDE_COUNT = 5
MAX_SIDE_FIELD_COUNT = 20

@dataclass
class FlashcardTemplate:
    id: UUID
    name: str
    concept_template_id: UUID
    sides: list[Side]
    created_at: datetime
    modified_at: datetime

    class Side:
        id: UUID
        name: Optional[str]
        fields: list[Field]

        class Field:
            id: UUID
            name: Optional[str]

    @classmethod
    def new(cls, name: str, concept_template_id: UUID, sides: list[Side]) -> ResultT[FlashcardTemplate]:
        if len(sides) > MAX_SIDE_COUNT:
            return ResultT[FlashcardTemplate].error(f"cannot have more than {MAX_SIDE_COUNT} sides")

        utc_time_now = datetime.now(timezone.utc)
        return ResultT[FlashcardTemplate].success(
            FlashcardTemplate(
                uuid.uuid4(),
                name,
                concept_template_id,
                sides,
                created_at=utc_time_now,
                modified_at=utc_time_now))
