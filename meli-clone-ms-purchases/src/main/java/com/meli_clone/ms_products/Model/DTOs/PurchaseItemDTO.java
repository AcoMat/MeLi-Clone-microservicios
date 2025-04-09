package com.meli_clone.ms_products.Model.DTOs;


public class PurchaseItemDTO {

    private Long productId;
    private Double price;
    private int quantity;

    public PurchaseItemDTO(Long productId, Double price, int quantity) {
        this.productId = productId;
        this.price = price;
        this.quantity = quantity;
    }

    public Long getProductId() {
        return productId;
    }

    public Double getPrice() {
        return price;
    }

    public int getQuantity() {
        return quantity;
    }
}
