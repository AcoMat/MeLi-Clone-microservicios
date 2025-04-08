package com.meli_clone.ms_products.Service.Interfaces;

import com.meli_clone.ms_products.Model.DTOs.PurchaseDTO;
import org.springframework.http.ResponseEntity;

import java.util.List;

public interface IPurchaseService {

    public PurchaseDTO registerPurchase(PurchaseDTO purchaseDTO);

    public List<PurchaseDTO> getAllPurchases();

    public PurchaseDTO getPurchaseById(Long purchaseId);
}
