package com.meli_clone.ms_products.Mappers;

import com.meli_clone.ms_products.Model.DTOs.NewPurchaseDTO;
import com.meli_clone.ms_products.Model.DTOs.PurchaseDTO;
import com.meli_clone.ms_products.Model.DTOs.PurchaseItemDTO;
import com.meli_clone.ms_products.Model.Entities.Purchase;
import com.meli_clone.ms_products.Model.Entities.PurchaseItem;
import org.springframework.stereotype.Component;

import java.util.stream.Collectors;

@Component
public class Mapper {


    public PurchaseItem toEntity(PurchaseItemDTO itemDTO) {
        return new PurchaseItem(itemDTO.getProductId(), itemDTO.getPrice(), itemDTO.getQuantity());
    }

    public PurchaseItemDTO toDTO(PurchaseItem item) {
        return new PurchaseItemDTO(item.getId(), item.getPriceAtPurchase(), item.getQuantity());
    }

    public PurchaseDTO toDTO(Purchase purchase) {
        return new PurchaseDTO(
                purchase.getPurchaseId(),
                purchase.getPurchaseDate(),
                purchase.getQuantity(),
                purchase.getItems().stream()
                        .map(this::toDTO)
                        .collect(Collectors.toList()),
                purchase.getTotalPrice()
        );
    }

}
