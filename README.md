# JWT - Seguridad en API's
-- Demo para pruebas de concepto en seguridad de API's --

¿Qué es JWT?

Los JSON Web Tokens (JWT) son actualmente un estándar en la autenticación de aplicaciones (mobile, web - como tendencias), pues permite de una forma simple identificarte con el servidor mediante un Token (algoritmo generado para la validación). Dicho token es generado por el servidor y es transmitido hacia el cliente (según la petición), el cual deberá presentar en cada invocación para poder ser autenticado.

¿Cómo se compone JWT?

La composición del formato de JWT es por 3 strings separados por puntos "."

Ejemplo: "eyJtbGciOiJIUzI1NiIsInR5cCI8IkpXVCJ9.eyJzdWIiOiI1NGE4Y2U2MThlOTFiMGIxMzY2NWUyZjkiLCJpYXQiOiIxNDI0MTgwNDg0IiwiZXhwIjoiMTQyNTM5MDE0MiJ9.yk4nouUteW54F1HbWtgg1wJxeDjqDA_8AhUPyjE5K0U"

Explicación por cada cadena string:

1.- Parte 1 - Cadena String (del ejemplo): "eyJtbGciOiJIUzI1NiIsInR5cCI8IkpXVCJ9" 

Esta primera parte identifica la cabecera "HEADER": se refiere a la cabecera del token, asimismo contiene otros 2 atributos:
- El tipo para el ejemplo un JWT.
- La codificación utilizada para este caso HMAC SHA256 (comúnmente usada, aunque ahora se recomienda SHA512).

Sin codificar sería la siguiente estructura:
{
 "alg": "HS256",
 "typ": "JWT"
}

2.- Parte 2 - Cadena String (del ejemplo): "eyJzdWIiOiI1NGE4Y2U2MThlOTFiMGIxMzY2NWUyZjkiLCJpYXQiOiIxNDI0MTgwNDg0IiwiZXhwIjoiMTQyNTM5MDE0MiJ9" 

Esta segunda parte identifica la carga útil "PAYLOAD": la cual está compuesta por los llamados JWT Claims donde irán colocados la atributos que definen nuestro token. En el ejemplo contamos con los siguientes:
- Sub: Identifica el sujeto del token, por ejemplo un identificador de usuario.
- Iat: Identifica la fecha de creación del token, válido para si queremos ponerle una fecha de caducidad. En formato de tiempo UNIX
- Exp: Identifica a la fecha de expiración del token. Podemos calcularla a partir del iat. También en formato de tiempo UNIX.

Sin codificar sería la siguiente estructura:
{
 "sub": "54a8ce618e91b0b13665e2f9",
 "iat": "1424180484",
 "exp": "1425390142"
}

3.- Parte 3 - Cadena String (del ejemplo): "yk4nouUteW54F1HbWtgg1wJxeDjqDA_8AhUPyjE5K0U" 

Esta tercera parte identifica la firma "SIGNATURE": consta en la firma del JSON Web Token. Está formada por los anteriores componentes (Header y Payload) cifrados en Base64 con una clave secreta (almacenada en nuestro backend). Así sirve de Hash para comprobar que todo está bien.

Sin codificar sería la siguiente estructura:
HMACSHA256(  
    base64UrlEncode(header) + "." + 
    base64UrlEncode(payload), secret
);

Apoyado en la fuente https://www.programacion.com.py/varios/que-es-json-web-token-jwt
