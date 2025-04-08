package com.meli_clone.ms_products.Mappers;

import com.meli_clone.ms_products.Model.DTOs.PurchaseDTO;
import com.meli_clone.ms_products.Model.DTOs.PurchaseItemDTO;
import com.meli_clone.ms_products.Model.Entities.Purchase;
import com.meli_clone.ms_products.Model.Entities.PurchaseItem;
import org.springframework.stereotype.Component;

import java.util.stream.Collectors;

@Component
public class Mapper {

    public Purchase toEntity(PurchaseDTO purchaseDTO) {
        Purchase purchase = new Purchase();
        purchase.setPurchaseId(purchaseDTO.getPurchaseId());
        purchase.setPurchaseDate(purchaseDTO.getPurchaseDate());
        purchase.setTotalPrice(purchaseDTO.getTotalAmount());
        purchase.setItems(
                purchaseDTO.getItems().stream()
                        .map(this::toEntity)
                        .collect(Collectors.toList())
        );
        return purchase;
    }

    public PurchaseItem toEntity(PurchaseItemDTO itemDTO) {
        PurchaseItem item = new PurchaseItem();
        item.setProductId(itemDTO.getProductId());
        item.setPriceAtPurchase(itemDTO.getPriceAtPurchase());
        item.setQuantity(itemDTO.getQuantity());
        return item;
    }

    public PurchaseDTO toDTO(Purchase purchase) {
        PurchaseDTO purchaseDTO = new PurchaseDTO();
        purchaseDTO.setPurchaseId(purchase.getPurchaseId());
        purchaseDTO.setPurchaseDate(purchase.getPurchaseDate());
        purchaseDTO.setTotalAmount(purchase.getTotalPrice());
        purchaseDTO.setItems(
                purchase.getItems().stream()
                        .map(this::toDTO)
                        .collect(Collectors.toList())
        );
        return purchaseDTO;
    }

    public PurchaseItemDTO toDTO(PurchaseItem item) {
        PurchaseItemDTO itemDTO = new PurchaseItemDTO();
        itemDTO.setProductId(item.getProductId());
        itemDTO.setPriceAtPurchase(item.getPriceAtPurchase());
        itemDTO.setQuantity(item.getQuantity());
        return itemDTO;
    }
}
