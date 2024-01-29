try:
    base = float(input('Please enter base : '))
    height = float(input('Please enter height : '))
except:
    base = 0
    height = 0

total = ((1/2) * (base * height))
print( 'Triangle area = %.2f' %total )
