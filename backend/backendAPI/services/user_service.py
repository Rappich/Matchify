from db.mongo import db
from models.user_model import User
from typing import Optional, List

class UserService:
    def __init__(self):
        self.collection = db["Users"]

    # Create a new user in the database
    async def create_user(self, user: User) -> str:
        user_dict = user.dict(by_alias=True)
        # Remove _id if None so MongoDB can generate it
        user_dict.pop("_id", None)
        result = await self.collection.insert_one(user_dict)
        return str(result.inserted_id)

    # Retrieve a user by username
    async def get_by_username(self, username: str) -> Optional[User]:
        user = await self.collection.find_one({"username": username})
        if user:
            user["_id"] = str(user["_id"])  # Convert ObjectId to string
            return User.parse_obj(user)
        return None

    # Retrieve a user by email
    async def get_by_email(self, email: str) -> Optional[User]:
        user = await self.collection.find_one({"email": email})
        if user:
            user["_id"] = str(user["_id"])
            return User.parse_obj(user)
        return None

    # Retrieve all users
    async def get_all_users(self) -> List[User]:
        users = []
        async for user in self.collection.find():
            user["_id"] = str(user["_id"])
            users.append(User.parse_obj(user))
        return users
