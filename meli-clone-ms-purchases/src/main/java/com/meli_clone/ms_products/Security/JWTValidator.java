package com.meli_clone.ms_products.Security;

import com.auth0.jwt.JWT;
import com.auth0.jwt.algorithms.Algorithm;
import com.auth0.jwt.exceptions.JWTVerificationException;
import com.auth0.jwt.interfaces.DecodedJWT;
import com.auth0.jwt.interfaces.JWTVerifier;
import lombok.extern.slf4j.Slf4j;
import org.springframework.beans.factory.annotation.Value;
import org.springframework.stereotype.Component;


@Slf4j
@Component
public class JWTValidator {

    private final String jwtSecret;
    private final JWTVerifier verifier;

    public JWTValidator(@Value("${app.jwt.secret}") String jwtSecret) {
        this.jwtSecret = jwtSecret;
        Algorithm algorithm = Algorithm.HMAC256(jwtSecret);
        this.verifier = JWT.require(algorithm).build();
    }

    public Long validateTokenAndGetSID(String token) {
        try {
            if (token == null || token.isEmpty()) {
                throw new IllegalArgumentException("Token is null or empty");
            }

            if (token.startsWith("Bearer ")) {
                token = token.substring(7);
            }

            DecodedJWT decodedJWT = verifier.verify(token);

            String sidString = decodedJWT.getClaim("sid").asString();
            if (sidString != null) {
                return Long.parseLong(sidString);
            }

            // If String approach fails, try direct asLong()
            return decodedJWT.getClaim("sid").asLong();
        } catch (JWTVerificationException e) {
            throw new IllegalArgumentException("Invalid JWT token", e);
        } catch (NumberFormatException e) {
            throw new IllegalArgumentException("Invalid sid format in token", e);
        }
    }
}