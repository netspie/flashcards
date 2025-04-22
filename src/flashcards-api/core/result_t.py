from __future__ import annotations

from dataclasses import dataclass
from typing import Generic, TypeVar

from core.result import Result

T = TypeVar('T')

@dataclass
class ResultT(Generic[T]):
    value: T | None
    errors: list[str]

    def isOk(self) -> bool:
        return self.value is None or any(self.errors)
    
    @classmethod
    def success(cls, value: T) -> ResultT[T]:
        return ResultT[T](value, [])
    
    @classmethod
    def error(cls, msg: str) -> ResultT[T]:
        return ResultT[T](None, [msg])

    @classmethod
    def fromResult(cls, result: Result) -> ResultT[T]:
        return ResultT[T](None, result.errors)