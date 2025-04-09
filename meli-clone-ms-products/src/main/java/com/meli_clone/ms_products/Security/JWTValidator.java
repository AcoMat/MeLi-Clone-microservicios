package com.meli_clone.ms_products.Security;

import com.auth0.jwt.JWT;
import com.auth0.jwt.algorithms.Algorithm;
import com.auth0.jwt.exceptions.JWTVerificationException;
import com.auth0.jwt.interfaces.DecodedJWT;
import com.auth0.jwt.interfaces.JWTVerifier;
import org.springframework.stereotype.Component;


@Component
public class JWTValidator {

    private static final String SECRET_KEY = "SUPER_SECRET_KEY_MELI_CLONE_DONT_GONNA_GIVE_YOU_UP";
    private static final String SID_CLAIM = "SID";

    private final JWTVerifier verifier;

    public JWTValidator() {
        Algorithm algorithm = Algorithm.HMAC256(SECRET_KEY);
        this.verifier = JWT.require(algorithm).build();
    }

    public Long validateTokenAndGetSID(String token) {
        DecodedJWT decodedJWT = verifier.verify(token);
        return decodedJWT.getClaim(SID_CLAIM).asLong();
    }
}