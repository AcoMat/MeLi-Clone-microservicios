package com.meli_clone.ms_products.Service.Implementations;

import com.meli_clone.ms_products.Mappers.Mapper;
import com.meli_clone.ms_products.Model.DTOs.PurchaseDTO;
import com.meli_clone.ms_products.Model.Entities.Purchase;
import com.meli_clone.ms_products.Repository.PurchaseRepository;
import com.meli_clone.ms_products.Service.Interfaces.IPurchaseService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class PurchaseService implements IPurchaseService {
    @Autowired private PurchaseRepository purchaseRepository;
    @Autowired private Mapper mapper;

    @Override
    public PurchaseDTO registerPurchase(PurchaseDTO purchaseDTO) {
        Purchase purchase = mapper.toEntity(purchaseDTO);
        purchaseRepository.save(purchase);
        return mapper.toDTO(purchase);
    }

    @Override
    public List<PurchaseDTO> getAllPurchases() {
        return null;
    }

    @Override
    public PurchaseDTO getPurchaseById(Long purchaseId) {
        return null;
    }
}
