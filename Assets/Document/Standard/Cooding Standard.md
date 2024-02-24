**Coding specification**

* 1. **Variable and function naming**
   
   * A method of representing variables and functions using hump nomenclature. Such as: playerScore
   * Class and structure names should start with a capital letter. Such as: GameManager
   * Constants should be all uppercase and use underscores to split words. Such as: MAX_PLAYERS
  
 * 2.  **Indent and  space**
 
    * Use  4 Spaces as the  indent  standard.
    * Add Spaces  before and after  operators to  improve  code  readability.
    
 * 3.  **Braces**

     * Add  line  breaks  before the  braces  of functions,  conditional  statements,  and  loop directions.
     * The  contents  of  the  braces  should  be  aligned  with  the  preceding  code,  and  there should  be consistent  indentation.
    
  * 4. **Comment the  specification**
  
      * The  purpose  of  adding  comments  is to  accurately  describe the functionality  of the code and the  purpose of the  implementation.
      * For complex algorithms or  logic, detailed  comments  should  be  provided  explaining  key steps and  design  ideas.
      * The copyright notice and author information should be annotated at the  beginning of  each file.
      * When code is modified, the comments should be updated accordingly to  maintain consistency  between code and  comments.
   
   * 5. **Develop  modularly**
       
       * Adopt modular development method to split the code into independent modules  to  improve  thereusability  of  the  code.
       * For  complex  modules,  smaller  functions  or  submodules  should  be  used  to  make the code structure clear  and  readable.
    
   * 6. **Classes  and  methods**
   
       * Classes should  have clear  responsibilities and functions, and  follow  the  single  responsibility  principle.
       * Methods should  be  properly encapsulated and should  not  reveal  unnecessary  details.
       * Avoid deep  nesting, with  no  more than three  layers  recommended.
    
    * 7. **Exception  handling**
    
        * Handle exceptions in code blocks that may cause exceptions to ensure the stability of program operation.
        * Avoid the way of catching all exceptions, and specific handling should be  performed according to different types of exceptions.
        
   * 8. **Error  logging**
   
       * Add  an  error  log  where  appropriate to  record  error  information  that  occurs  while the  program is  running.
       * The error log should contain useful context information to facilitate  troubleshooting and  repair.
     
   * 9. **Class**
   
     * Use the Pascal rules for class names, i.e., capitalize the first letter.
     * Name the class with a noun or noun phrase that reflects its function.
     * Do not use specific meaning prefixes such as 'I', 'C', or '_'.
     * Custom Exception classes should end with exception.
   
  
  * 10. **Class field (class member)**
     
     * Use the camel rule to name class member variable names, that is, the first word (or word abbreviation) in lower case.
     * Class field variable names can be prefixed with '-'

 * 11. **In each class, document comments (time, field, formal parameter, return value introduction)**
 
 * 12. **Increase the encoding file, for example: when it is based on binary, what encoding should be stored.**
