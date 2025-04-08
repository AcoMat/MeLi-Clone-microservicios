package com.meli_clone.ms_products.Controller.Implementations;

import com.meli_clone.ms_products.Controller.Interfaces.IPurchaseController;
import com.meli_clone.ms_products.Model.DTOs.PurchaseDTO;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RestController;

import java.util.List;

@RestController
public class PurchaseController implements IPurchaseController {
    @Autowired

    @Override
    @PostMapping("/purchase")
    public ResponseEntity<String> registerPurchase(Long userId, Long productId, int quantity) {

        return null;
    }

    @Override
    public ResponseEntity<List<PurchaseDTO>> getAllPurchases() {
        return null;
    }

    @Override
    public ResponseEntity<PurchaseDTO> getPurchaseById(Long purchaseId) {
        return null;
    }
}
