from motor.motor_asyncio import AsyncIOMotorClient
from dotenv import load_dotenv
import os

# load environment variables from .env file
load_dotenv()

# Get MongoDB connection details from environment variables
MONGO_URL = os.getenv("MONGODB_CONN")
MONGO_DB_NAME = os.getenv("MONGODB_DBNAME")


# Validate that the required environment variables are set
if not MONGO_URL or not MONGO_DB_NAME:
    raise ValueError("MONGODB_CONN or MONGODB_DBNAME is not set in the .env file.")

# Create an asynchronous MongoDB client
client = AsyncIOMotorClient(MONGO_URL)
db = client[MONGO_DB_NAME]
