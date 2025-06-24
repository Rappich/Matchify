UML Class Diagram Description
User

Attributes: userId, username, email, passwordHash, profileImageUrl, preferences, createdAt

Relationships:

One-to-many with Swipe (a user can have many swipes)

Many-to-many with Match (a user can be in many matches)

One-to-many with ContentItem (user can create content)

ContentItem

Attributes: contentId, type, title, description, images, metadata, createdBy, createdAt

Relationships:

One-to-many with Swipe (content can be swiped by many users)

One-to-many with Match (matches linked to this content)

Swipe

Attributes: swipeId, userId, contentId, direction, timestamp

Relationships:

Many-to-one to User

Many-to-one to ContentItem

Match

Attributes: matchId, userIds (two users), contentId, matchedAt

Relationships:

Many-to-many with User (two users per match)

Many-to-one with ContentItem

PlantUML Code
plantuml
Kopiera
Redigera
@startuml
class User {
  +ObjectId userId
  +String username
  +String email
  +String passwordHash
  +String profileImageUrl
  +Map preferences
  +Date createdAt
}

class ContentItem {
  +ObjectId contentId
  +String type
  +String title
  +String description
  +List images
  +Map metadata
  +ObjectId createdBy
  +Date createdAt
}

class Swipe {
  +ObjectId swipeId
  +ObjectId userId
  +ObjectId contentId
  +String direction
  +Date timestamp
}

class Match {
  +ObjectId matchId
  +List userIds
  +ObjectId contentId
  +Date matchedAt
}

User "1" -- "0..*" Swipe : makes >
ContentItem "1" -- "0..*" Swipe : receives >
User "1" -- "0..*" ContentItem : creates >
Match "1" -- "2" User : involves >
ContentItem "1" -- "0..*" Match : relates to >
@enduml
How to view this diagram
Copy the PlantUML code above.

Use an online PlantUML editor like PlantText or PlantUML Visualizer to paste and render it.

You get a neat class diagram visualizing your data model.

