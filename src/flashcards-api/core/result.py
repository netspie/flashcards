from __future__ import annotations
from dataclasses import dataclass

from core.result_t import T, ResultT

@dataclass  
class Result:
    errors: list[str]

    def isOk(self) -> bool:
        return any(self.errors)
    
    @classmethod
    def success(cls) -> Result:
        return Result([])
    
    @classmethod
    def error(cls, msg: str) -> Result:
        return Result([msg])
    
    @classmethod
    def fromResult(cls, result: ResultT[T]) -> Result:
        return Result(result.errors)