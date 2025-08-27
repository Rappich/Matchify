from fastapi import FastAPI
from fastapi.middleware.cors import CORSMiddleware
from routes import user_routes

app = FastAPI()

app.add_middleware(
    CORSMiddleware,
    allow_origins=["http://localhost:8081"],
    allow_credentials=True,
    allow_methods=["*"],
    allow_headers=["*"],
)

app.include_router(user_routes.router)


@app.get("/")
async def root():
    return {"message": "API is running"}
