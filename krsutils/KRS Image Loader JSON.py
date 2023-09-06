import json

# Función para generar un objeto JSON para una palabra dada
def generar_objeto_json(palabra):
    imagespath = []
    palabra_minusculas = palabra.lower().strip()  # Convertir la palabra a minúsculas y eliminar espacios
    for i in range(1, 5):
        imagen = f"images\\{palabra_minusculas}_{i}.jpeg"
        imagespath.append(imagen)

    objeto_json = {
        "Resolved": False,
        "Imagespath": imagespath,
        "Word": palabra  # Mantener la palabra original en mayúsculas
    }

    return objeto_json

# Función para crear una lista de objetos JSON a partir de una lista de palabras
def generar_lista_json(palabras):
    lista_json = [generar_objeto_json(palabra) for palabra in palabras]
    return lista_json

# Obtener la lista de palabras como entrada del usuario
entrada = input("Pon las palabras entre comas porfa: ")

# Dividir la entrada en una lista de palabras
palabras = entrada.split(',')

# Generar la lista de objetos JSON
lista_objetos_json = generar_lista_json(palabras)

# Imprimir la lista de objetos JSON
for objeto_json in lista_objetos_json:
    print(json.dumps(objeto_json, indent=2))

# Esperar a que el usuario presione Enter antes de cerrar la ventana
input("Presiona Enter para salir...")

