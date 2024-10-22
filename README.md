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


