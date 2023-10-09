variable "tags" {
  default = {
    Env = "demo-3"
  }
}

variable "public_subnets" {
  type = list(string)
  default = [ "10.0.3.0/24", "10.0.4.0/24", "10.0.5.0/24"]
}

variable "private_subnets" {
  type = list(string)
  default = [ "10.0.6.0/24", "10.0.7.0/24", "10.0.8.0/24"]
}

variable "vpc_cidr" {
  default = "10.0.0.0/16"
}