# mutiny
A repository hosting commits of the GBC 3D Mutiny project.

### Work Flow

Our Master ("main") Branch will act as the release/working branch and the structure will follow like so:
```
 main
   |  \__  Feature (Name)
   |          |
   |          |
   |          |
   |          |
   |          |
 main      Feature (Name)
   |          |
   |          |
   |       Feature (Name)
 main __ /
```
Whenever we merge a Feature branch into the Developer branch, we will use pull requests so that at least one other collaborator can check for merge conflicts or game-breaking edits. <br/>
When we complete a Feature and merged it into Developer in a working state, we will delete the corresponding Feature branch. If we are to work on that Feature again, we will make another branch for that Feature with the same name.<br/>
To name a Feature branch, using the naming convention: Feature (Name) where Feature is replaced with the feature you are working on and Name is your name. By doing so, we know the feature being added, so what it can affect, and the person who worked on it, in case we need to contact them about the changes.

Feature Naming Conventions:
Feature (Name)

**REMINDER**: When you start working on this project at any point, please make sure that you have pulled the most recent commits and are working in the correct branch. If you fail to do this, it could result in merge conflicts that we do not want.
