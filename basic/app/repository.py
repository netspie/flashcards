from dataclasses import dataclass, field
from typing import Callable, Generic, Optional, Protocol, TypeVar

TID = TypeVar('TID', contravariant=True)
T = TypeVar('T')

@dataclass
class Repository(Protocol, Generic[T, TID]):
    async def get_all(self) -> Optional[list[T]]: ...
    async def get_by_id(self, id: TID) -> Optional[T]: ...
    async def add(self, item: T) -> None: ...
    async def update(self, item: T) -> None: ...
    async def delete(self, id: TID) -> bool: ...

@dataclass
class InMemoryRepository(Repository[T, TID], Generic[T, TID]):
    _get_id: Callable[[T], TID | None]
    _data: dict[TID, T] = field(default_factory=dict)

    async def get_all(self) -> Optional[list[T]]:
        return list(self._data.values()) if self._data else None

    async def get_by_id(self, id: TID) -> Optional[T]:
        return self._data.get(id, None)

    async def add(self, item: T) -> None:
        id = self._get_id(item)
        if id != None:
            self._data[id] = item

    async def update(self, item: T) -> None:
        id = self._get_id(item)
        if id != None:
            self._data[id] = item

    async def delete(self, id: TID) -> bool:
        return self._data.pop(id, None) is not None
    
