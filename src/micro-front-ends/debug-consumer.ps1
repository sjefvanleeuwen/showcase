Start-Process -FilePath "npm" -ArgumentList "run dev:serve" -WorkingDirectory "./consumer/product"
Start-Process -FilePath "npm" -ArgumentList "run dev:serve" -WorkingDirectory "./common/form-engine"
Start-Process -FilePath "npm" -ArgumentList "run dev:serve" -WorkingDirectory "./consumer/portal"
