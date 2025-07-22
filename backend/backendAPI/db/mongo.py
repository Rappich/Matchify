from motor.motor_asyncio import AsyncIOMotorClient
from dotenv import load_dotenv
import os
from pathlib import Path

# Load .env file from the project root directory
env_path = Path(__file__).resolve().parent.parent / ".env"
load_dotenv(dotenv_path=env_path)

# Fetch environment variables
MONGO_URL = os.getenv("MONGODB_CONN")
MONGO_DB_NAME = os.getenv("MONGODB_DBNAME")

if not MONGO_URL or not MONGO_DB_NAME:
    raise ValueError("MONGODB_CONN or MONGODB_DBNAME is not set in the .env file.")

# Initialize MongoDB client
client = AsyncIOMotorClient(MONGO_URL)
db = client[MONGO_DB_NAME]


import asyncio

async def test_fetch_user():
    user = await db["Users"].find_one({"username": "testuser"})
    if user:
        print(" Found user:")
        print(user)
    else:
        print(" No user found with username 'testuser'.")

if __name__ == "__main__":
    asyncio.run(test_fetch_user())
