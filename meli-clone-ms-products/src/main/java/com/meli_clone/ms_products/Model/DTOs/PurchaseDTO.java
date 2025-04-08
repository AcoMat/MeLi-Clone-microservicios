package com.meli_clone.ms_products.Model.DTOs;

import java.math.BigDecimal;
import java.time.LocalDateTime;
import java.util.List;

public class PurchaseDTO {

    private Long purchaseId;
    private LocalDateTime purchaseDate;
    private BigDecimal totalAmount;
    private List<PurchaseItemDTO> items;


    public Long getPurchaseId() {
        return purchaseId;
    }

    public void setPurchaseId(Long purchaseId) {
        this.purchaseId = purchaseId;
    }

    public LocalDateTime getPurchaseDate() {
        return purchaseDate;
    }

    public void setPurchaseDate(LocalDateTime purchaseDate) {
        this.purchaseDate = purchaseDate;
    }

    public BigDecimal getTotalAmount() {
        return totalAmount;
    }

    public void setTotalAmount(BigDecimal totalAmount) {
        this.totalAmount = totalAmount;
    }

    public List<PurchaseItemDTO> getItems() {
        return items;
    }

    public void setItems(List<PurchaseItemDTO> items) {
        this.items = items;
    }
}