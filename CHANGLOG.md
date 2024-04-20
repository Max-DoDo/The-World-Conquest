# The World Conquest CHANGELOG

---

## [0.3.0] - 2024-04-20

### Added

* Full support for attacking other countries added.
* A comprehensive round loop system has been implemented.
* 
* Added troop selection via scrollbar.
* The popup text panel can be used now.
* Added dice functionality, attacks now depend on dice rolls to determine the outcome.

### Changed

* The Country class has been refactored.
* Refactored numerous classes to improve logic coherence.
* Refactored the method of acquiring troops for players.
* Information about adjacent countries is now stored using a dictionary, eliminating the need for collision box detection.
* Some UI files have been renamed to improve readability for English speakers.
* Privious CHANGLOG.md file have been refactored to make it more readability.

### BugFix

* Fixed the scrollbar could not display well in different zoom scale.
* The key "Nothern Europe" in contry manager dictionary has renamed to "Northern Europe".
* Fixed issue with abnormal troop loss after attacking other countries.
* When the init troops. each country now will have 5 troops instead of 6.

### Known bug

* The popup panel does not work properly when too much information needs to be displayed within a short period of time.

## [0.2.0] - 2024-04-19

### Added

* This game now will run by the event handle by user instead of a "Game Core".
* Each player now has their own representative color.
* Players can now choose a series of countries to start with.
* Each player start with 20 troops.
* An information panel has been added.
* Added "Current player" text and "troop" text in information panel.
* Added a setting button in the game scene. It do nothing right now.
* The UI panel can run in almost different resolution.
* The UI panel can display the "The player currently operating the computer"'s information now.
* new information panel UI.
* Unfinished player AI, currently not able to use.
* button click sound.
* A constant class for storage the static value.
* A 3D project for dice.
* A series of button UI.
* User avatar UI elements have been added.
* UI elements displaying numbers from 0 to 9 have been implemented.

### Changed

* The maxinum player number decrised to 6 from 8.
* Change the structure of UI folder.
* A series of code refactoring.

### Removed

* Client class has been removed.

---

## [0.1.0-Beta] - 2024-03-21

### Fixed

* Fixed incorrect camera position at different resolutions.
* Fixed the issue where the zoom function of the lens may fail under different resolutions
* Fixed the issue where the camera movement function may fail under different resolutions
* Fixed the issue where the zoom of the camera under different frame numbers is not as expected.
* Fixed the issue where camera movement was not as expected under different frame numbers.

### Changed

* Modified the logic of camera movement, Now the camera will try to be in the middle of the map.

---

## [0.1.0 - Alpha] - 2024-03-17

### Added

* Add game scene.
* Add all country in the map.
* Add background.
* Add different color in the country where in the different contienent.
* Add raycast to the object(country) in the map.
* Add mouse click function(testing). The country be clicked will change color to red now.
* Add new Font file.
* Add background texture.
* Add sprint document 2.
* Add main menu 3D project.
* Add version 0.0.4 testing file.
* Camera can move with keyboard "WASD" or "UP","DOWN","LEF","RIGHT" now.
* Camera can zoom in and zoom out with mouse scroll wheel now.
* Camera movement is limited to a certain range.
* Camera zoom is limited to a certain range.
* Camera zoom is more smooth now.
* Camera movement changes with zoom level.
* Camera movement and zoom is more stable in different frame rate.

### Changed

* Removed useless file generate by Mac operating system upload by UI.
* Map UI and Font UI update.Their resolution is now higher.
* Planning document update.
* Refactor the project file path.
* Refactor the project file name in UI folder.

---
## [0.0.4] - 2024-02-25

### Added

* Sprint Document 1 start.
* Main menu button can jump to other scene now.

### Changed

* Low level document update.

### Log

* Sprint 1 now start. Please notice your work.
* Main menu will be refactor in this sprint.

---

## [0.0.3] - 2024-02-25

### Added

* New Unity project related folder added in assets folder.
* Add opening scene.
* Add  menu scene and four button.
* Add related method for the four button.

### Changed

* Modified project path to rationalize them.
* Modified gitignore file to avoid upload VScode cache file upload into git.
* .gitignore file update for avoid log file upload into Github.
* Rename "Lunch" to "Launch".

---

## [0.0.2] - 2024-02-23

### Added

* Add Unity Project.
* Add .gitignore file for avoid large file upload to Github.
* Add Design document.
* Add Planning document.
* Add Meeting log.
* Add Sprint document.
* Add Standard document.
* Add Test document.

### Changed

* Remove Planning document in markdown file.
* Revise document typesetting.
* Modified project paths to rationalize them.

---

## [0.0.1] - 2024-02-20

### Added

* Create repo in Github.
* The original hight level design document was transferred.
* The original low level design document was transferred.
* The original test standard document was transferred.
* The original Canvas document was transferred.
* The original meeting log was transferred.
* Add README file
* Add CHANGELOG file
* Add sprint document folder
* Add MIT open source license
* Add game code and source folder but its empty now.

### Changed

* Modifie the path structure of documents required in this project.

### Log

* Various standard documents are not sufficient, they will not be uploaded for the time being.

---