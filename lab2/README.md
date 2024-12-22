# Контрольные вопросы [ОТЧЕТ]:
### 1. Примеры задач:
1.  **Операторы ветвления:**
-  Проверка, является ли число четным или нечетным.
-  Определение, попадает ли введенное значение в заданный диапазон.
-  Выбор действия в зависимости от уровня доступа пользователя (например, администратор, пользователь, гость).

2. **Операторы цикла:**
- Вычисление факториала числа.
-  Суммирование чисел в массиве.
-  Поиск максимального элемента в списке чисел.

### 2. Отличия составных логических выражений от простых:

- Простые логические выражения содержат только одно логическое условие (например, x > 5).
- Составные логические выражения объединяют несколько простых условий с помощью логических операторов (например, x > 5 && x < 10).

Примеры:
- Простые:
x == 10
y != 0

- Составные:
x > 5 && x < 10
y == 0 || z == 1

### 3. Замените строку кода с оператором if:
```
int x;
if (n % 3 == 0)
{
    x = n / 3;
}
else
{
    x = n * 3;
}
```
### 4. Переменные каких типов можно использовать в качестве селекторов switch? В качестве селекторов switch можно использовать переменные следующих типов:
```
int
char
string
enum
byte
sbyte
short
ushort
long
ulong
```

### 5. Что делают операторы break и continue?

- **break:** завершает выполнение текущего цикла или оператора switch и передает управление следующему оператору после цикла или switch.
- **continue:** пропускает оставшуюся часть текущей итерации цикла и переходит к следующей итерации.

### 6. Цикл, который считает сумму всех четных чисел в диапазоне от 0 до 20:
```
int sum = 0;
for (int i = 0; i <= 20; i++)
{
    if (i % 2 == 0)
    {
        sum += i;
    }
}
```
### 7. Отличие оператора do while от оператора while:

- Оператор while сначала проверяет условие, и если оно ложно, тело цикла не выполняется ни разу.
- Оператор do while сначала выполняет тело цикла, а затем проверяет условие. Таким образом, тело цикла выполняется как минимум один раз, даже если условие ложно.