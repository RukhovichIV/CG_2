# CG_2

<div style="text-align:right">Рухович Игорь</div>
<div style="text-align:right">381808-1</div>

Отчёт по лабораторной работе №2. Визуализация томограмм.

Так выглядит окно приложения:![](screenshots/main_screen.png)

Иерархия меню:

- Файл
  - Открыть (открытие нового файла с томограммой)
- Режим (режимы визуализации)
  - Визуализация четырехугольниками
  - Визуализация одной текстурой
  - Визуализация лентами четырехугольников

Верхний ползунок отвечает за номер отображаемого слоя томограммы. Слева самый верхний слой, справа - нижний.

Нижние ползунки регулируют диапазон отображаемых цветовых значений. Минимальное значение отображается в чёрный цвет, максимальное в белый. Данная томограмма содержит значения от 0 до 24399, но плотность их распределения после 3000 стремится к нулю. Поэтому было принято решение сделать максимально достижимое ползунками значение - 3000. Все значения больше этого будут отображаться белым цветом на томограмме. Минимальная ширина полосы значений ограничена 255, т. к. при меньшем значении теряется информативность рисунка.

Для удобной навигации по томограмме рекомендуется выставить минимальное значение так, чтобы исследуемый орган был едва виден (практически черным), а ширину полосы значений максимально уменьшить, чтобы была заметна разница между близкими элементами.

Таким образом можно достичь весьма неплохих отображений:

- Тазовая кость:![](screenshots/pelvic_bone.png)
- Почки (темные круги слева и справа в верхней части):![](screenshots/kidneys.png)
- Нижняя часть сердца и прилегающие сосуды (справа в верхней части):![](screenshots/heart_and_blood_vessels.png)
- Лёгкие (правое слева и кусочек левого справа; из-за наличия сердца левое лёгкое меньше):![](screenshots/lungs.png)

Реализованы 3 режима отображения (одной текстурой, четырехугольниками и лентами четырехугольников). Данные производительности показаны для Release сборки .NET Framework 4.6.1, OpenTK 1.1 на ОС Windows 10, базовая тактовая частота процессора 3.5ГГц, базовая тактовая частота графического модуля 8.1ГГц, 16ГБ оперативной памяти, 3ГБ памяти графического процессора. Под производительностью имеется в виду количество рассчитанных (а не показанных) компьютером кадров.

- Одной текстурой. При необходимости перерисовки изображения производительность колеблется от 1тыс. до 7тыс. кадров в секунду. При статичном изображении за секунду успевает рассчитаться порядка 9.5тыс. кадров.![](screenshots/one_texture.png)
- Отображение четырехугольниками. При любом состоянии производительность составляет 16-17 кадров в секунду.![](screenshots/quads.png)
- Отображение лентами четырехугольников. При любом состоянии производительность составляет 33-35 кадров в секунду. Это ровно в 2 раза больше, чем в предыдущем случае (что логично, т. к. в предыдущем случае происходит примерно 4N операций, а в этом около 2N, где N - количество пикселей в изображении).![](screenshots/quad_strip.png)

