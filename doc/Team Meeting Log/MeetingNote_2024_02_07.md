# Software Engineering G6046 - Team Meeting Note

* **Team Number:**  
    Not generate yet

* **Names of team members present:** 
    * `Max Wang`
    * `Wu Tong`
    * `Tao Yiwen`
    * `Song Zhenmao`
    * `Sun Weiyi`

* **Meeting moderator：Max Wang**


    **(All members were present)**


* **Meeting format:**   
    physical meeting in library

* **Date and time:(YYYY-MM-DD HH:MM - HH:MM)**  
    2024-02-07 19:00 - 20:50


## Pre-meeting objective
* Continue to refine the design plan

  * The imperfection of the design scheme will lead to the failure of the project to start, thus affecting the progress of the project.
  
 * Rectification of project specifications
  
   * The project specification is the primary criterion for our project, and we have already started to prepare for the initial stage of the project at the first meeting.
   
  * Since Friday is Chinese New Year, the meeting originally scheduled for Friday was moved to Wednesday
    
    * In China, New Year is the most important festival of the year, we can not go home, so we will spend the time in school, to finish the project as the main goal.
 
 ## Issues discussed at this meeting

**1.Refinement of the design document (ongoing)**

* After intense discussion, we increased the detailed scheme of AI, added the difficulty of AI design in the advanced design document, and how to achieve the difficulty level, such as: how long can the operation time of a difficult AI not exceed, whether the difficulty can be changed in the middle of the game, or whether the AI can be replaced with a real person.

* Detailed description of the main interface style.
   
   * After our discussion, we decided to start from the user's point of view, compare ourselves to a user, experience the interface that each user may use, and refine each interface.
  
 * Finally decide to use own dedicated window, not the default window.(Our preliminary estimate is that there should be no less than 10 separate Window)
 
 * Views on Resolution
   
   * Because considering whether it is easy to implement later, we decided to adapt with the resolution of the user's screen.
  
  * In the high-level design document, we decided to add each component that could interact.
  
  * Consider in-game communication issues, such as：how to communicate using a server client; What kind of messages the client should send to the server at what time are all issues to consider. (This issue will cover threading later）
  
  * Dice are also a very important part of the game. ' Max Wang ' believes that the dice should be designed as static fields, because using static fields will occupy less memory and be more considerate of users.


**2. Revision of design specification discussion (ongoing)** 
  
  * About low-level design documentation
  
    * The low-level design document is a more detailed representation of the high-level design document, which will become the main core for the team to write the game in the future.
    
    * It was decided to write after the advanced design document was completed by the end of the week.
  
  * Document name Keeping copies does not require the version number to be written on the name.

  * Add names and comments when the document is submitted, using three or four letters to indicate what is being submitted, for example: 'feat' for added features, 'doc' for submitted document, 'ref' for refactoring.
  
 * Strengthen versioning control by indicating version status for each document

 * Correct the unreasonable place of the previous design specification, and carry out further detail processing.

**3. Add risk management**

 * Risk control is also an integral part of this project.

 * We're also talking about where the risks are. Such as：
 
    * The game design document is not compliant, and the game code cannot be written.
    
    *  The only UI designer is sick, unable to create, and who will replace him next.
    
  * Align mission objectives with risk management, The project manager is responsible for the combination of risk management and project allocation, so that the project process is not affected.
  
  ## Other Remarks

* We need more details to get better
* We need strong debate instead of "whatever"

**END 2024-2-7 **
