package com.meli_clone.ms_products.Model.DTOs;

import java.time.Instant;
import java.util.List;

public class PurchaseDTO {

    private Long purchaseId;
    private Instant purchaseDate;
    private int quantity;
    private List<PurchaseItemDTO> items;
    private Double totalPrice;

    public PurchaseDTO(Long purchaseId, Instant purchaseDate, int quantity, List<PurchaseItemDTO> items, Double totalPrice) {
        this.purchaseId = purchaseId;
        this.purchaseDate = purchaseDate;
        this.quantity = quantity;
        this.items = items;
        this.totalPrice = totalPrice;
    }

    public Long getPurchaseId() {
        return purchaseId;
    }

    public Instant getPurchaseDate() {
        return purchaseDate;
    }

    public int getQuantity() {
        return quantity;
    }

    public List<PurchaseItemDTO> getItems() {
        return items;
    }

    public Double getTotalPrice() {
        return totalPrice;
    }
}