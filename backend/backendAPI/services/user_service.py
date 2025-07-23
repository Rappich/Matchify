from db.mongo import db
from models.user_model import User
from bson.objectid import ObjectId
from typing import Optional, List

# UserService class to handle user-related database operations
# This class provides methods to create, retrieve, and manage users in the MongoDB database.
class UserService:
    def __init__(self):
        self.collection = db["Users"]

    # Create a new user in the database
    # This method takes a User object, converts it to a dictionary, and inserts it into
    async def create_user(self, user: User) -> str:
        user_dict = user.dict(by_alias=True)
        # Ensure _id is not included in the user_dict if it is None
        if user_dict.get("_id") is None:
            user_dict.pop("_id", None)
        result = await self.collection.insert_one(user_dict)
        return str(result.inserted_id)

    # Retrieve a user by their username or email
    # This method checks if a user exists by username or email and returns the User object if
    async def get_by_username(self, username: str) -> Optional[User]:
        user = await self.collection.find_one({"username": username})
        if user:
            user["_id"] = str(user["_id"])  # convert ObjectId to string
            return User(**user)
        return None

    # Retrieve a user by their email
    # This method checks if a user exists by email and returns the User object if found.
    async def get_by_email(self, email: str) -> Optional[User]:
        user = await self.collection.find_one({"email": email})
        if user:
            user["_id"] = str(user["_id"])
            return User(**user)
        return None

    # Retrieve all users from the database
    # This method returns a list of all users in the database as User objects.
    async def get_all_users(self) -> List[User]:
        users = []
        async for user in self.collection.find():
            user["_id"] = str(user["_id"])
            users.append(User(**user))
        return users
