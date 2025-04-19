from fastapi import FastAPI

app = FastAPI()
		
@app.get('/health')
async def index() -> str:
    return "I'm alive"