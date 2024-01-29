import random

def generate_question():
    num1 = random.randint(1, 10)
    num2 = random.randint(1, 10)
    answer = num1 + num2
    return f"What is {num1} + {num2}?", answer

def check_answer(user_answer, correct_answer):
    return user_answer == correct_answer

def math_game():
    score = 0
    num_questions = 5

    for _ in range(num_questions):
        question, correct_answer = generate_question()
        user_answer = int(input(question + "\nEnter your answer: "))
        
        if check_answer(user_answer, correct_answer):
            print("Correct!\n")
            score += 1
        else:
            print(f"Wrong! The correct answer is {correct_answer}\n")

    print(f"Your final score is {score}/{num_questions}")

if __name__ == "__main__":
    math_game()
