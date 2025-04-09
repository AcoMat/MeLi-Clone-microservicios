package com.meli_clone.ms_products.Controller;

import com.meli_clone.ms_products.Model.DTOs.NewPurchaseDTO;
import com.meli_clone.ms_products.Model.DTOs.PurchaseDTO;
import com.meli_clone.ms_products.Service.PurchaseService;
import jakarta.validation.Valid;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.net.URI;
import java.util.List;

@RestController
public class PurchaseController {
    @Autowired
    PurchaseService purchaseService;

    @PostMapping("/purchases")
    public ResponseEntity<String> registerPurchase(@Valid @RequestBody NewPurchaseDTO purchaseDTO, @RequestHeader("Authorization") String token) {
        PurchaseDTO new_purchase = purchaseService.registerPurchase(purchaseDTO, token);
        return ResponseEntity.created(URI.create("/purchases/" +new_purchase.getPurchaseId())).body("Purchase registered successfully");
    }

    @GetMapping("/purchases")
    public ResponseEntity<List<PurchaseDTO>> getAllPurchases() {
        return null;
    }

    @GetMapping("/purchases/{purchaseId}")
    public ResponseEntity<PurchaseDTO> getPurchaseById(@RequestParam Long purchaseId) {
        return null;
    }
}
