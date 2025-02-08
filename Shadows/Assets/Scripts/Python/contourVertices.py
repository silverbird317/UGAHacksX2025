import numpy as np
import cv2
from matplotlib import pyplot as plt

# read image
img = cv2.imread('masked_image.png')

# convert to grayscale
gray = cv2.cvtColor(img, cv2.COLOR_BGR2GRAY)

# apply thresholding
ret, thresh = cv2.threshold(gray, 127, 255, 0)

# find contours
contours, hierarchy = cv2.findContours(thresh, cv2.RETR_TREE, cv2.CHAIN_APPROX_SIMPLE)

print(contours)

# draw contours on the original image
img_contours = cv2.drawContours(img.copy(), contours, -1, (255, 255, 0), 2)

# display results
plt.figure(figsize = (10, 5))
plt.subplot(1, 2, 1)
plt.imshow(cv2.cvtColor(img, cv2.COLOR_BGR2RGB))
plt.title('Original Image')
plt.axis('off')

plt.subplot(1, 2, 2)
plt.imshow(cv2.cvtColor(img_contours, cv2.COLOR_BGR2RGB))
plt.title('Contours')
plt.axis('off')

plt.show()