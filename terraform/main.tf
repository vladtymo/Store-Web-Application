module "network" {
    source = "./modules/network"  
    vpc_cidr_block = var.vpc_cidr
    tags = var.tags
    public_subnets = var.public_subnets
    private_subnets = var.private_subnets
}

module "ecr" {
    source = "./modules/ecr"  
    tags = var.tags
}