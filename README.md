<img alt="UCU" src="https://www.ucu.edu.uy/plantillas/images/logo_ucu.svg"
width="150"/>

# Universidad Católica del Uruguay

## Facultad de Ingeniería y Tecnologías

### Programación II

# ¿Por qué usamos las clases que usamos?

Para empezar creamos la clase abstracta Character la cual tiene todos los parámetros y métodos que deben heredar los personajes, ya sean heroes o enemigos. Evaluamos también tener solo la clase abstracta heroe y que luego "Villano" herede de todo de ahí, o viceversa, sin embargo preferimos hacerlo con Character para que batalla pueda utilizar dichos métodos o parámetros más facilmente. 

Hero y Enemy heredan todo de Character pero el método para conseguir el VP varía dependiendo de cual de los dos sean, ambos son una clase abstracta para que los personajes puedan heredarlo de ellos (los que son evil heredan de enemy y los que son good de Hero). 

El resto de clases e interfaces las dejamos como estaban.


