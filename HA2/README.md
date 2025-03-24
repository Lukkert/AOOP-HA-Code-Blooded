# 🎓 University Management App  
## 🔐 Login Information  
| Role     | Username | Password |
|----------|----------|----------|
| **Student** | `Klaus` | `2222`  |
| **Teacher** | `John`| `1111`  |

## 📖 Overview  
This project is a University Management App built using **Avalonia** and following the **MVVM** architecture. The app allows students and teachers to manage subjects effectively with data persistence through a **JSON file**.  

## 🚀 Features  
### 👨🎓 Student Functionality  
- View available and enrolled subjects.  
- Enroll in and drop subjects.  
- View subject details (name, teacher, description).  

### 👨🏫 Teacher Functionality  
- Create, edit, and delete subjects.  
- View subjects they have created.  

### ⚙️ System Functionality  
- Login screen for both teachers and students.
- Data persistence using a JSON file.

## 🧪 Testing
- ### Unit Testing (xUnit)
    - Passed ✅ **User Authentication Unit Test:** `AuthService_Can_Validate_Existing_Users_And_Reject_Invalid_Ones()`

    - Passed ✅ **Subject Creation Unit Test:** `Teacher_Can_Create_A_New_Subject()`

    - Passed ✅ **Subject Enrollment Unit Test:** `Student_Can_Enroll_In_A_Subject()`

- ### Functional Testing
    - **Student Functionality Tests:**
        - Passed ✅ **Enrollment Test:** When a student enrolls in an available subject, it appears in the "Enrolled Subjects" section. Once the action is performed, the student receives a popup window containing a confirmation message.

        - Passed ✅ **Drop Subject Test:** When a student drops a subject in which he/she is enrolled in, it appears in the "Available Subjects" section. Once the action is performed, the student receives a popup window containing a confirmation message.

    - **Teacher Functionality Tests:**
        - Passed ✅ **Create Subject Test:** When a teacher creates a new subject, it will appear in the Teachers subject section as well as in the "Available Subjects" sections for all students.


        - Passed ✅ **Delete Subject Test:** When a teacher deletes a selected subject, the subject will be removed from the Teachers subject section. The deletion will reflect as well in the "Available Subjects" sections for all students.


    - **System-Level Tests:**
        - Passed ✅ **Login Test:** When a user enters a valid student or teacher username and password, the user will be directed to student or teacher dashboard, depending on the user's role. It is not possible for a student to log in to the teacher’s dashboard and vice-versa. If the user enters an incorrect username or password a small message is displayed.


        - Passed ✅ **Data Persistence Test:** Any actions performed by students (enroll or drop a subject) or teachers (create or edit a subject) are saved in UserData.json.



- ### **UI Testing** – User Interface Testing with **Avalonia.Headless.XUnit**.
    - Student Headless Tests
        - Passed ✅ **Enrollment Test:** `Student_Can_Enroll_In_Subject()`

        - Passed ✅ **Drop Subject Test:** `Student_Can_Drop_Subject()`

    - Teacher Headless Tests
        - Passed ✅ **Create Subject Test:** `Teacher_Can_Create_Subject()`

        - Passed ✅ **Delete Subject Test:** `Teacher_Can_Delete_Subject()`

        - Passed ✅ **Edit Subject Test:** `Teacher_Can_Edit_Subject()`

    - System-Level Headless Tests:
        - Passed ✅ **Data Persistence Test:** `Data_Persists()`

## 🎯 Additional Task  
- **Password hashing** was implemented to improve login security.

## 🧑💻 Contributors  
**Code Blooded ( Gene Enrick Miguel Giroy, Lukas Ekkert, Deividas Petrulis)**  
The group worked on the project simultaneously while being in physical/digital presence 
in order to prevent unequal distribution of workload.