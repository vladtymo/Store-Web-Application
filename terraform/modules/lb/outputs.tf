output "load_balancer_arn" {
  value = aws_lb.lb.arn
}

output "target_group_arn" {
  value = aws_lb_target_group.app_tg.arn
}

output "alb_dns_name" {
  value = aws_lb.lb.dns_name
}

output "alb_zone_id" {
  value = aws_lb.lb.zone_id
}
