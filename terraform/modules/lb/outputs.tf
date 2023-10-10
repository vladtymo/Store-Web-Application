output "load_balancer_arn" {
  value = aws_lb.lb.arn
}

output "target_group_arn" {
  value = aws_lb_target_group.app_tg.arn
}
