using System;
using System.Collections.Generic;

namespace Game
{
    public class Student
    {
        public string name; // The student's name
        public List<Course> myCourses; // A list of the classes the student is taking

        public Student(string studentName = "No Name")
        {
            name = studentName; // Set the student's name
            myCourses = new List<Course>(); // Create an empty list to hold their classes
        }

        // This is how you add a new class for the student
        public void AddNewCourse(string courseName)
        {
            // Make a new class
            Course newCourse = new Course(courseName);
            // Add the new class to the student's list of classes
            myCourses.Add(newCourse);
        }

        // This tells you how many classes the student is taking
        public int HowManyCourses()
        {
            return myCourses.Count; // Count how many classes are in the list
        }
    }

    public class Course
    {
        // Information about the class
        public string name; // The name of the class
        public List<StudySet> studyThings; // A list of things to study for this class

        // Setting up the class when it's created
        public Course(string courseName)
        {
            name = courseName; // Set the name of the class
            studyThings = new List<StudySet>(); // Make an empty list for study sets
        }

        // How to add something new to study for this class
        public void AddNewStudySet(string studySetName)
        {
            // Make a new study set
            StudySet newStudySet = new StudySet(studySetName);
            // Add it to the list of things to study
            studyThings.Add(newStudySet);
        }

        // How many things are there to study in this class?
        public int HowManyStudySets()
        {
            return studyThings.Count; // Count how many study sets are in the list
        }

        // public function 
        public string Name
        {
            get { return name; }
            set { name = value;  }
        }
    }

    public class StudySet
    {
        // Information about what to study
        public string name; // The name of this study set
        public List<Flashcard> cards; // A list of flashcards in this set

        // Setting up the study set
        public StudySet(string studySetName)
        {
            name = studySetName; // Set the name of the study set
            cards = new List<Flashcard>(); // Make an empty list for flashcards
        }

        // How to add a new flashcard to this study set
        public void AddNewFlashcard(string question, string answer)
        {
            // Make a new flashcard
            Flashcard newCard = new Flashcard(question, answer);
            // Add it to the list of flashcards
            cards.Add(newCard);
        }

        // How many flashcards are in this study set?
        public int HowManyFlashcards()
        {
            return cards.Count; // Count how many flashcards are in the list
        }
    }

    public class Flashcard
    {
        // What's on the flashcard
        public string question; // The question on the front
        public string answer; // The answer on the back

        // Setting up the flashcard
        public Flashcard(string cardQuestion, string cardAnswer)
        {
            question = cardQuestion; // Set the question
            answer = cardAnswer; // Set the answer
        }
    }
}
