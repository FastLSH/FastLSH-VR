from numpy import genfromtxt
import numpy as np
from sklearn.preprocessing import normalize
from sklearn.feature_selection import SelectFromModel
from sklearn.ensemble import ExtraTreesClassifier


filePath = "author.csv"


with open (filePath, 'rb') as f:
    data = f.readlines()

class_set = []
c_count = 0
class_list = []
data = data[1:]

for d in data:
    cla = d.split(",")[1]
    if not class_set.__contains__(cla):
        class_set.append(cla)
        c_count+=1
    class_list.append(c_count)

print class_list


glass = genfromtxt(filePath, delimiter=',')
glass = glass[1:]
glass = np.delete(glass, [0,1], axis=1)




Column_Normalized = normalize(glass, norm='max', axis=0)

norm_multiply = np.multiply(Column_Normalized, 10)

np.savetxt('authorNorm.csv', norm_multiply, delimiter = ',', fmt='%f')


clf = ExtraTreesClassifier()
clf = clf.fit(Column_Normalized, class_list)
print clf.feature_importances_

print np.argsort(clf.feature_importances_)


