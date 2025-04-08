package com.meli_clone.ms_products.Controller.Interfaces;

import com.meli_clone.ms_products.Model.DTOs.PurchaseDTO;
import org.springframework.http.ResponseEntity;

import java.util.List;

public interface IPurchaseController {

    ResponseEntity<String> registerPurchase(Long userId, Long productId, int quantity);

    ResponseEntity<List<PurchaseDTO>> getAllPurchases();

    ResponseEntity<PurchaseDTO> getPurchaseById(Long purchaseId);
}
