import mysql.connector
import sys

mydb = mysql.connector.connect(host='127.0.0.1', user='root', passwd='1234567890',database='Infectious')

query = ''

cursor = mydb.cursor()

if sys.argv[1] == '1':
	query = 'SELECT * FROM Infectious_disease'
elif sys.argv[1] is '2':
	query = 'SELECT * FROM Categorie_of_infectious_disease'
elif sys.argv[1] is '3':
	query = 'SELECT * FROM Infectious_disease JOIN Categorie_of_infectious_disease ON Infectious_disease.Categorie_ID=Categorie_of_infectious_disease.ID'

cursor.execute(query)
data = cursor.fetchall()

for row in data:
	print(row)

cursor.close()
mydb.close()
