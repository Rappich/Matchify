# UML Class Diagram Description

## User

**Attributes:**  
- `userId` (ObjectId)  
- `username` (string)  
- `email` (string)  
- `passwordHash` (string)  
- `profileImageUrl` (string)  
- `preferences` (Map) — JSON key-value pairs for user settings  
- `createdAt` (Date)  

**Relationships:**  
- One-to-many with `Swipe` (a user can have many swipes)  
- Many-to-many with `Match` (a match always involves exactly two users)  
- One-to-many with `ContentItem` (a user can create many content items)  

---

## ContentItem

**Attributes:**  
- `contentId` (ObjectId)  
- `type` (string) — e.g., recipe, travel, workout  
- `title` (string)  
- `description` (string)  
- `images` (List) — list of image URLs  
- `metadata` (Map) — flexible key-value pairs for extra info  
- `createdBy` (ObjectId) — userId of creator  
- `createdAt` (Date)  

**Relationships:**  
- One-to-many with `Swipe` (content can be swiped by many users)  
- One-to-many with `Match` (content can be involved in many matches)  

---

## Swipe

**Attributes:**  
- `swipeId` (ObjectId)  
- `userId` (ObjectId)  
- `contentId` (ObjectId)  
- `direction` (string) — "left" or "right"  
- `timestamp` (Date)  

**Relationships:**  
- Many-to-one to `User`  
- Many-to-one to `ContentItem`  

---

## Match

**Attributes:**  
- `matchId` (ObjectId)  
- `userIds` (List) — exactly two userIds involved in the match  
- `contentId` (ObjectId)  
- `matchedAt` (Date)  

**Relationships:**  
- Many-to-many with `User` (exactly two users per match)  
- Many-to-one with `ContentItem`  

---

# PlantUML Code

```plantuml
@startuml
' User entity
class User {
  +ObjectId userId
  +String username
  +String email
  +String passwordHash
  +String profileImageUrl
  +Map preferences  ' JSON key-value pairs for user settings
  +Date createdAt
}

' ContentItem entity
class ContentItem {
  +ObjectId contentId
  +String type      ' e.g., recipe, travel, workout
  +String title
  +String description
  +List images      ' List of image URLs
  +Map metadata     ' Flexible key-value pairs
  +ObjectId createdBy
  +Date createdAt
}

' Swipe entity
class Swipe {
  +ObjectId swipeId
  +ObjectId userId
  +ObjectId contentId
  +String direction  ' "left" or "right"
  +Date timestamp
}

' Match entity
class Match {
  +ObjectId matchId
  +List userIds     ' Exactly 2 users per match
  +ObjectId contentId
  +Date matchedAt
}

' Relationships
User "1" -- "0..*" Swipe : makes >
ContentItem "1" -- "0..*" Swipe : receives >
User "1" -- "0..*" ContentItem : creates >
Match "1" -- "2" User : involves >
ContentItem "1" -- "0..*" Match : relates to >
@enduml
