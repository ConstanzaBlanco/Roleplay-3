<img alt="UCU" src="https://www.ucu.edu.uy/plantillas/images/logo_ucu.svg"
width="150"/>

# Universidad Católica del Uruguay

## Facultad de Ingeniería y Tecnologías

### Programación II

# ¿Por qué usamos las clases que usamos?

Para empezar creamos la clase abstracta Character la cual tiene todos los parámetros y métodos que deben heredar los personajes, ya sean heroes o enemigos. Evaluamos también tener solo la clase abstracta heroe y que luego "Villano" herede de todo de ahí, o viceversa, sin embargo preferimos hacerlo con Character para que batalla pueda utilizar dichos métodos o parámetros más facilmente. 

Hero y Enemy heredan todo de Character pero el método para conseguir el VP varía dependiendo de cual de los dos sean, ambos son una clase abstracta para que los personajes puedan heredarlo de ellos (los que son evil heredan de enemy y los que son good de Hero). 

El resto de clases e interfaces las dejamos como estaban y no vimos necesario un cambio.

# ¿Que tanto cumplen con los principios SOLID?

Character:

-Cumple con SRP ya que se encarga de crear todo lo que debe tener un personaje, cosa que hace que cumpla con Expert al tener toda la información que debe tener uno.

-Cumple con DIP ya que las clases de alto nivel (Hero y Enemy) dependen de esta abstracción.


-Cumple con LSP ya que Hero y Enemy al ser estar heredando de character, podrían sustituirlo sin que se rompa el código

-Utiliza Plimorfismo ya que tiene metodos como el defenseValue los cuales se pueden sobreescribir en distintas partes del código.

Todo esto aplica para Hero y Enemy también los cuales al ser una clase abstracta que hereda casi todo de Character, sus características son prácticamente las mismas

Todos los tipos de personaje no mágicos (Evilknight, GoodArcher,etc):

-Cumplen con SRP ya que tienen la responsabilidad única de representar el personaje (dependiendo de cual clase sea, qué personaje). Esto hace que cumplan con Expert al tener toda la información necesaria para representar dicho personaje.

-Cumplen con LSP ya que pueden ser utilizados como un Enemy o Hero sin romper el comportamiento esperado.


Good Wizard y EvilWizard:

-Cumplen con SRP ya que tienen la responsabilidad de gestionar sus items y cuanto daño hacen/reciben con ellos. Y también son Expertos en manejar dicha lógica.

-Cumplen con LSP ya que pueden ser utilizados como un Enemy o Hero, siempre y cuando estos implementen IMagicCharacter, sin romper el comportamiento esperado.

Todos los Items menos SpellsBook:

-Cumplen con SRP ya que tienen la función única de brindar un dúmero de ataque o defensa fijo. Lo que los hace expertos en dicha información

-Cumplen con LSP ya que pueden ser sustituídos por cualquier otro item que implemente la misma interfaz sin remper el funcionamiento del código.


SpellsBook:

-Cumple con SRP ya que tiene la responsabilidad de saber toda la lógica alrededor de los hechizos del libro. Esto lo vuelve experta en manejar la cantidad de hechizos que tiene libro y como afectan al item en sí.

-Cumple con LSP ya que se puede crear otra clase que implemente IMagicalAttackItem y IMagicalDefenseItem sin afectar la lógica del código.

-Incluye polimorfismo ya que los métodos AttackValue y DefenseValue invocan los métodos de cada ISpell, lo que permite que cada hechizo defina su propio cálculo sin que SpellsBook necesite en sí conocer los detalles.

Encounters:

-Cumple con SRP ya que tiene la única responsabilidad de gestionar la batalla entre los héroes y enemigos. Es experta en todo lo que gire en torno a esto, como las interacciones entre los personajes o cuando está terminada y cuando no.

-Cumple con LSP ya que cualquier clase derivada de Hero/Enemy puede ser útil para implementar los métodos de encounters, siempre y cuando dicha clase implemente d emanera correcta Hero o Enemy.

-Cumple con DIP ya que depende de clases abstractas de alto nivel que son Hero y Enemy.

-Hay polimorfismo ya que puedes crear subclases que apliquen los métodos de encounters sin cambiar la lógica de la clase.
