data "aws_caller_identity" "current" {}

resource "aws_ecrpublic_repository" "ecr" {
  repository_name = "ecr-demo-3"

  tags = merge(var.tags, { "Name" = "ecr-demo-3" })
}

data "aws_iam_policy_document" "ecr" {
  statement {
    sid    = "ECR policy"
    effect = "Allow"

    principals {
      type        = "AWS"
      identifiers = [data.aws_caller_identity.current.account_id]
    }

    actions = [
      "ecr:GetDownloadUrlForLayer",
      "ecr:BatchGetImage",
      "ecr:BatchCheckLayerAvailability",
      "ecr:PutImage",
      "ecr:InitiateLayerUpload",
      "ecr:UploadLayerPart",
      "ecr:CompleteLayerUpload",
      "ecr:DescribeRepositories",
      "ecr:GetRepositoryPolicy",
      "ecr:ListImages",
      "ecr:DeleteRepository",
      "ecr:BatchDeleteImage",
      "ecr:SetRepositoryPolicy",
      "ecr:DeleteRepositoryPolicy",
    ]
  }
}
resource "aws_ecrpublic_repository_policy" "ecr" {
  repository_name = aws_ecrpublic_repository.ecr.repository_name
  policy          = data.aws_iam_policy_document.ecr.json
}